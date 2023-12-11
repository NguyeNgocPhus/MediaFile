namespace Benchmark.Models;
public class Message
{
    public long id { get; set; }
    public string content { get; set; }
    public long account_id { get; set; }
    public long inbox_id { get; set; }
    public long conversation_id { get; set; }
    public int message_type { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public bool? @private { get; set; }
    public int? status { get; set; }
    public string source_id { get; set; }
    public int content_type { get; set; }
    public string content_attributes { get; set; }
    public string sender_type { get; set; }
    public long? sender_id { get; set; }
    public string external_source_ids { get; set; }
    public string additional_attributes { get; set; }
}
