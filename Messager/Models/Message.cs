using System.ComponentModel.DataAnnotations;
using Messager.Models;

public class Message
{
    public int id { get; set; }

    public string content { get; set; }

    public int senderId { get; set; }
    public int receiverId { get; set; }
}