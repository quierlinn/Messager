using System.ComponentModel.DataAnnotations;

namespace Messager.Models;

public class Message
{ 
    public int id { get; set; }
    public string content { get; set; }
    public int senderId { get; set; }
    public int receiverId { get; set; }
    public User sender { get; set; }
    public User receiver { get; set; }
}