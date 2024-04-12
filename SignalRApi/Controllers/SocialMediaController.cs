using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList() 
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto CreatesocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Icon = CreatesocialMediaDto.Icon,
                Title = CreatesocialMediaDto.Title,
                Url = CreatesocialMediaDto.Url,
            });
            return Ok("SocialMedia is created");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("SocialMedia is Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto socialMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Icon = socialMediaDto.Icon,
                Title = socialMediaDto.Title,
                Url = socialMediaDto.Url,
                SocialMediaID = socialMediaDto.SocialMediaID
            });
            return Ok("SocialMedia is updated");
        }
    }
}
