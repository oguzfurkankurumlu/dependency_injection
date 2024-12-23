using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dependecy_injection.Models;

namespace Dependency_Injection.Controllers;

public class HomeController : Controller
{


    // Ctor Injection !!
    // Program.cs dosyasında, AddScoped metodu ile, Helper sınıfını ekledik!!
    // Helper sınıfına HomeController içerisinde ihtiyacımız olduğunda, 
    // ctor kullanarak, helper sınıfının controller içerisinde gelmesini sağladık
    // bu yöntem ile ,asla sınıfları new lememize gerek kalmayacaktır!!

    public IHelper _helper;
    public MakeJson _makeJson;
    public HomeController(IHelper helper, MakeJson makeJson)
    {
        this._helper = helper;
        this._makeJson = makeJson;
    }

    public IActionResult Index()
    {

        // klasik yöntem : Helper sınıfın içerisindeki metodu kullanalım

        //Helper helper= new Helper();
        //helper.SayHello();

        // Yeni yöndem, ctor ile nesne örneği aldık

        string returnValue = _helper.SayHello();

        string makejsonReturnValue = _makeJson.Make();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}