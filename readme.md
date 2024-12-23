Dependency Injection (Bağımlılık Enjeksiyonu), yazılım geliştirme sırasında bir sınıfın ihtiyaç duyduğu bağımlılıkları (dependencies) dışarıdan almasını sağlayan bir tasarım desenidir. Bu desen, kodun daha esnek, daha modüler ve daha kolay test edilebilir olmasını sağlar.

Sayfalar arası sınıf transferi gibi düşünebiliriz.
----------------------------------------------------------------------------------------------
Infastructor adında bir klasör oluşturdum.
içinde Helper.cs adında bir dosya açtim
   
    public interface IHelper 
    interfacei olusturdum

    public class Helper :IHelper{
        
        public string SayHello(){
        return "Hello";
        }
    }
    altına bunu ekledim
----------------------------------------------------------------------------------------------
Home controllerda her defasında newlememek ıcın program cs e 
newlemek istedigim sınıfın ınterface ı ve meototunu verdim.
----------------------------------------------------------------------------------------------
Program.cs e 
    // DEpendency Injection ile, nesne örnepini kullanacağımız sınıfı ve interface'i verdik!!
    // Action içerisinde bu helper sınıfını kullanalım!!
        builder.Services.AddScoped<IHelper,Helper>();
        builder.Services.AddScoped<IPayment,Payment>();

farklı bunlar, bunları ekledim.
payment daha sonra olusturuldu.
----------------------------------------------------------------------------------------------
Home controllera gittim 
    
    Ihelper tıpınde  (interface tıpınde) bir degisken aldım 
    public IHelper _helper;

    ctor yazdım içine interface veya degısken al
    
    public HomeController(IHelper helper){
        _helper = helper
        //mapping yaptım _helperi  helpera mapledim.

        this._helper = helper 
        da yapabilirim 
    }


    public IActionResult Index()
    {
        string returnvalue= _helper.Sayhello()
        return View();
    }

----------------------------------------------------------------------------------------------
Interfacelerin ıcınde metot olmaz.!!
İMZA OLUR SADECE 

Interface'in Gövdesiz ve Gövdeli Hali
Bir interface hem gövdesiz hem de gövdeli metotları birlikte barındırabilir:

    public interface IHelper
    {
        void SayHello(); // Gövdesiz (zorunlu uygulama)
        
        public void SayGoodbye() // Gövdeli (isteğe bağlı)
        {
            Console.WriteLine("Goodbye from Default Implementation!");
        }
    }

----------------------------------------------------------------------------------------------
DependencyController olusturdum. 

    public class DependencyController : Controller
    {

        public IHelper _helper;
        public DependencyController(IHelper helper)
        {
            _helper = helper;
           
        }

    public IActionResult Index()
    {
        string returnvalue =  _helper.SayHello();
        return View();
    }

 }
----------------------------------------------------------------------------------------------
View a depencency klasoru acıp ındex ıcıne vıew verdik. 
----------------------------------------------------------------------------------------------
Payment.cs açtım
IPayment interfacei olusturdum  

    public interface IPayment{
    public string Pay();
    }


    public class Payment : IPayment
    {
        public string Pay()
        {
            return "pay çalıştı";
        }
    }

----------------------------------------------------------------------------------------------
    
DepencencyControllera Ekleme yaptık yazdıgımızı

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

----------------------------------------------------------------------------------------------
// c# da yazılan her sınıfın bir interfacesi olması gerekmektedir. Ancak internfacesi olmasa da dependency injection olarak eklenebilir

    builder.Services.AddScoped(typeof(MakeJson));
