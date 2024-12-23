using Microsoft.AspNetCore.Mvc;

public class DependencyController : Controller
{

    public IHelper _helper;
    public IPayment _payment;

    public DependencyController(IHelper helper, IPayment payment)
    {
        _helper = helper;
        _payment = payment;
    }
    public IActionResult Index()
    {
        string returnValue = _helper.SayHello();

        string payReturnValue = _payment.Pay();

        return View();
    }
}