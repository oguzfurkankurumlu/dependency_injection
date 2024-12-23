# Dependency Injection (Bağımlılık Enjeksiyonu) Nedir?
Dependency Injection, yazılım geliştirme sırasında bir sınıfın ihtiyaç duyduğu bağımlılıkları (dependencies) dışarıdan almasını sağlayan bir tasarım desenidir. Bu desen, kodun daha esnek, modüler ve kolay test edilebilir olmasını sağlar.

Dependency Injection'ı, **"sayfalar arası sınıf transferi"** gibi düşünebiliriz.

---

## Proje Adımları

### 1. Infrastructure Klasörü ve Helper.cs Dosyası
- **Infrastructure** adında bir klasör oluşturuldu.
- Bu klasör içerisinde **Helper.cs** dosyası açıldı ve aşağıdaki kodlar yazıldı:

```csharp
public interface IHelper
{
    string SayHello();
}

public class Helper : IHelper
{
    public string SayHello()
    {
        return "Hello";
    }
}
```

---

### 2. Program.cs Dosyasına Dependency Injection Tanımlamaları

Program.cs dosyasına aşağıdaki kodlar eklendi:

```csharp
// Dependency Injection ile, nesne örneğini kullanacağımız sınıfı ve interface'i tanımlıyoruz.
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IPayment, Payment>();
```

Burada:
- `AddScoped<IHelper, Helper>()` ile `IHelper` interface'ini implement eden `Helper` sınıfı, Dependency Injection ile sisteme kayıt edildi.
- Daha sonra **Payment** için aynı işlem gerçekleştirildi.

---

### 3. HomeController Düzenlemeleri
- **HomeController** içinde Dependency Injection kullanılarak `IHelper` interface'ini tanımlıyoruz.

```csharp
public class HomeController : Controller
{
    private readonly IHelper _helper;

    public HomeController(IHelper helper)
    {
        _helper = helper; // Mapping işlemi
    }

    public IActionResult Index()
    {
        string returnValue = _helper.SayHello();
        return View();
    }
}
```

**Açıklamalar:**
- `ctor` (constructor) ile `IHelper` tipi bir bağımlılığı (`helper`) içeri aldık.
- `helper`'ı `_helper` değişkenine atadık (mapping).
- **Dependency Injection sayesinde** `new` anahtar kelimesini kullanmadan `Helper` sınıfının bir örneğini (`instance`) oluşturduk.

---

### 4. Interface'lerin Gövdesiz ve Gövdeli Halleri
C# 8.0 ile birlikte interface'lerin içinde gövde içeren metotlar tanımlanabiliyor. Örneğin:

```csharp
public interface IHelper
{
    void SayHello(); // Gövdesiz metot (zorunlu uygulama)

    public void SayGoodbye() // Gövdeli metot (isteğe bağlı)
    {
        Console.WriteLine("Goodbye from Default Implementation!");
    }
}
```

---

### 5. DependencyController Oluşturulması
- Yeni bir **DependencyController** oluşturuldu.

```csharp
public class DependencyController : Controller
{
    private readonly IHelper _helper;

    public DependencyController(IHelper helper)
    {
        _helper = helper;
    }

    public IActionResult Index()
    {
        string returnValue = _helper.SayHello();
        return View();
    }
}
```

---

### 6. Payment.cs Dosyası
- **IPayment** adında bir interface oluşturuldu ve `Payment` sınıfı tarafından implement edildi:

```csharp
public interface IPayment
{
    string Pay();
}

public class Payment : IPayment
{
    public string Pay()
    {
        return "Pay çalıştı";
    }
}
```

---

### 7. DependencyController Geliştirilmesi
- **DependencyController** sınıfına `IPayment` eklendi:

```csharp
public class DependencyController : Controller
{
    private readonly IHelper _helper;
    private readonly IPayment _payment;

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
```

---

### 8. View Oluşturulması
- **Views** klasörü altına `Dependency` adında bir klasör açıldı.
- Bu klasör içine `Index.cshtml` dosyası eklendi ve ilgili View tanımlandı.

---

## Sonuç
- Dependency Injection ile sınıf bağımlılıkları dışarıdan alınarak kod daha temiz ve kolay yönetilebilir hale geldi.
- `IHelper` ve `IPayment` gibi interface'ler sayesinde bağımlılıkları değiştirmek kolaylaştı.
- View tarafında veriler işlenebilir hale geldi.

