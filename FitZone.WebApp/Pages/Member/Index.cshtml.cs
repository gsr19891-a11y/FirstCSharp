using FitZone.Application.Services.Interfaces;
using FitZone.Domain.Models.DTOs.MembersDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitZone.WebApp.Pages.Member
{
    public class IndexModel : PageModel
    {

        private readonly IMemberService _memberService;

            public IndexModel(IMemberService memberService)
        {
            _memberService = memberService;
        }


        public List<MemberDTO> Members { get; set; } = new List<MemberDTO>();

        public void OnGet()
        {
        }
    }
}
