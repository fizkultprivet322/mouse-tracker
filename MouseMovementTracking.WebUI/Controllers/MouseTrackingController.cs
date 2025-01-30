using Microsoft.AspNetCore.Mvc;
using MouseMovementTracking.Application.Interfaces;

namespace MouseMovementTracking.WebUI.Controllers;

public class MouseTrackingController : Controller
{
    private readonly IMouseTrackingService _mouseTrackingService;

    public MouseTrackingController(IMouseTrackingService mouseTrackingService)
    {
        _mouseTrackingService = mouseTrackingService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SaveMouseTrackingData([FromBody] dynamic request)
    {
        string jsonData = request.data.ToString();
        await _mouseTrackingService.SaveMouseTrackingDataAsync(jsonData);
        return Ok();
    }
}