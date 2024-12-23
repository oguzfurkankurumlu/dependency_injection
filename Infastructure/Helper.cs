public interface IHelper{
    public string SayHello();
}

public class Helper :IHelper{
    public string SayHello(){
        return "Hello";
    }

}