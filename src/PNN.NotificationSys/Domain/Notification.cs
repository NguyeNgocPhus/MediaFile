namespace PNN.NotificationSys.Domain;
public class Notification
{
    // ex : order-001 : success , order-002 : fail  ,v,v

    public string Type { get; set; } // order, product
    public int SenderId {  get; set; }
    public int ReceiveId { get; set; }
    public string Content { get; set; }
    public object? Options { get;set; }
    public DateTime CreatedAt { get; set;    }

}
