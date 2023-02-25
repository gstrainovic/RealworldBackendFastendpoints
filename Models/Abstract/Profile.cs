namespace Model.Abstract;

public abstract class Profile : Model.Abstract.User.Base
{
  public HashSet<string> Following { get; set; } 
}