using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// تنظیمات نمایشی و ارزیابی برای یک بخش از سوال.
/// شامل موقعیت متن، پاراگراف هدف، واژه‌نامه، و محدودیت نوشتاری.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "PassageProperties")]
public class PassageProperties : DataPrimitive, IValidatable
{
    /// <summary>
    /// فاصله متن از بالای صفحه به تعداد خطوط.
    /// مشخص می‌کند از کدام خط متن به داوطلب نمایش داده شود.
    /// </summary>
    [XmlAttribute("ReadingTopScrollLine")]
    [DataMember]
    public short ReadingTopScrollLine { get; set; }

    /// <summary>
    /// شماره پاراگراف هدف در متن.
    /// برای تمرکز یا ارجاع در سوالات تحلیلی.
    /// </summary>
    [XmlAttribute("ReadingParagraph")]
    [DataMember]
    public short ReadingParagraph { get; set; }

    /// <summary>
    /// واژه‌نامه یا تعریف واژه مشخص‌شده در متن.
    /// برای کمک به درک مطلب یا ارزیابی واژگان.
    /// </summary>
    [XmlElement("ReadingGlossary")]
    [DataMember]
    public string ReadingGlossary { get; set; } = "";

    /// <summary>
    /// حداکثر تعداد کلمات مجاز در پاسخ نوشتاری.
    /// برای کنترل ارزیابی و محدودیت داوطلب.
    /// </summary>
    [XmlElement("WritingMaxWordCount")]
    [DataMember]
    public string WritingMaxWordCount { get; set; } = "";

    /// <summary>
    /// اعتبارسنجی تنظیمات بخش برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (ReadingTopScrollLine < 0)
            errors.Add(new("ReadingTopScrollLine", "Invalid", "Scroll line must be zero or positive."));

        if (ReadingParagraph < 0)
            errors.Add(new("ReadingParagraph", "Invalid", "Paragraph number must be zero or positive."));

        return errors;
    }
}