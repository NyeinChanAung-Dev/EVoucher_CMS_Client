using EVoucher_CMS_Client.APIRepo;
using EVoucher_CMS_Client.Helper;
using EVoucher_CMS_Client.Models.RequestModels;
using EVoucher_CMS_Client.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EVoucher_CMS_Client.Controllers
{
    [Authorize]
    public class EVoucherController : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            ViewBag.pagename = "eVoucherPage";
            ViewBag.page = page;
            ViewBag.pageSize = pageSize;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> _EVoucherList(short Status = 1, int page = 1, int pageSize = 10)
        {
            GetEVoucherListingRequest _requestData = new GetEVoucherListingRequest()
            {
                Status = Status,
                PageNumber = page,
                PageSize = pageSize
            };

            string tokenString = getTokenString();
            var Url = string.Format("api/evoucher/getevoucherlist?status={0}&page={1}&pageSize={2}", Status, page, pageSize);

            PagedListModel<GetEVoucherListingResponse> result = await APIRequest<PagedListModel<GetEVoucherListingResponse>>.Get(Url, tokenString);
            var model = new PagingModel<GetEVoucherListingResponse>();
            if (result.TotalCount > 0 && result.TotalPages > 0)
            {
                var pagedList = new StaticPagedList<GetEVoucherListingResponse>(result.Results, page, pageSize, result.TotalCount);
                model.Results = pagedList;
                model.TotalPages = result.TotalPages;
                model.TotalCount = result.TotalCount;
            }
            else
            {
                model.Results = null;
                model.TotalPages = 0;
                model.TotalCount = 0;
            }

            return PartialView("_EVoucherList", model);
        }

        [HttpGet]
        public async Task<IActionResult> _ViewEVDetail(string VoucherNo)
        {
            var Url = string.Format("api/evoucher/getevoucherdetail?VoucherNo={0}", VoucherNo);
            string tokenString = getTokenString();
            GetEVoucherDetailResponse result = await APIRequest<GetEVoucherDetailResponse>.Get(Url, tokenString);

            return PartialView("_ViewEVDetail", result);
        }


        [HttpGet]
        public IActionResult _UpserEVoucher()
        {
            SubmitEVoucherRequest _request = new SubmitEVoucherRequest();
            return PartialView("_UpserEVoucher", _request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _UpsertEV(SubmitEVoucherRequest _request)
        {
            string Url = "api/evoucher/upsertevoucher";
            string tokenString = getTokenString();
            SubmitEVoucherResponse response = await APIRequest.PostEV(Url, _request, tokenString);

            if (response != null)
            {
                return Json("Success");
            }
            else
            {
                return Json("Fail");
            }
        }


        public string getTokenString()
        {
            return User.FindFirst(claim => claim.Type == "ct:Custom:accessToken")?.Value;
        }

    }
}
