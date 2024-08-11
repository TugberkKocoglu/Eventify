using Eventify.Application.Abstractions.Services;
using Eventify.Application.Abstractions.Services.Concrete;
using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Eventify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ExportService _exportService;

        public EventsController(IEventService eventService, ExportService exportService)
        {
            _eventService = eventService;
            _exportService = exportService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEvents([FromQuery]Pagination pagination)
        {
            var events = await _eventService.GetAllEventsAsync(pagination);
            return Ok(events);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEvent(CreateEventDTO createEventDTO)
        {
            await _eventService.CreateEventAsync(createEventDTO);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExportEvents([FromQuery]Pagination pagination,string path)
        {
            var events = await _eventService.GetAllEventsAsync(pagination);
            await _exportService.ExportEventAsync(events, path);
            return Ok();
        }

    }
}
