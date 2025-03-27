using System.ComponentModel.DataAnnotations.Schema;

namespace Messager.Models;
public class User
{
    public int id { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
}