using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع توضیح یا توصیه نمایشی به داوطلب.
/// برای کنترل نحوه نمایش پیام‌ها در فرم آزمون.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "CommentType")]
public enum CommentType : byte
{
    /// <summary>
    /// توصیه معمول و عمومی.
    /// بدون تأکید خاص، برای راهنمایی ساده.
    /// </summary>
    [EnumMember]
    [XmlEnum("c0")]
    Normal = 0,

    /// <summary>
    /// توصیه مهم با تأکید.
    /// معمولاً با فونت ضخیم یا رنگ خاص نمایش داده می‌شود.
    /// </summary>
    [EnumMember]
    [XmlEnum("c1")]
    Bold = 1,

    /// <summary>
    /// هشدار جدی یا پیام بحرانی.
    /// برای جلب توجه فوری داوطلب.
    /// </summary>
    [EnumMember]
    [XmlEnum("c2")]
    Highlight = 2,

    /// <summary>
    /// پیام جلب توجه یا تأکید نرم.
    /// معمولاً با فونت مورب یا استایل خاص نمایش داده می‌شود.
    /// </summary>
    [EnumMember]
    [XmlEnum("c3")]
    Italic = 3
}