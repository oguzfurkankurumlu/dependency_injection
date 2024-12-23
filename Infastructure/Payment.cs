

// DEpendency Injection konusunda, iki sınıfı birbirine referans etmek sorun yaratacaktır. DEpendency Injection'ın en dikkat edilmesi gerken konu budur!!


public interface IPayment{

    public string Pay();
}
public class Payment : IPayment
{
    //public IHelper _helper;
    //public Payment(IHelper helper)
    //{
       // _helper=helper;
    //}

    public Payment()
    {
        
    }
    public string Pay()
    {
        return "pay çalıştı";
    }
}