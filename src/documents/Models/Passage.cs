using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// یک بخش نمایشی در سوال آزمون.
/// می‌تواند شامل متن، صوت، تصویر، یا اطلاعات تکمیلی باشد.
/// برای نمایش همزمان با سوال یا به‌صورت مستقل.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "Passage")]
public class Passage : DataPrimitive, IValidatable
{
    /// <summary>
    /// متن نمایشی همزمان با فایل.
    /// می‌تواند خالی باشد (مثلاً در فایل‌های صوتی یا تصویری).
    /// </summary>
    [XmlAttribute("Text")]
    [DataMember]
    public string Text { get; set; } = "";

    /// <summary>
    /// لیست فایل‌های صوتی یا تصویری مرتبط با این بخش.
    /// می‌تواند خالی باشد.
    /// </summary>
    [XmlElement("EmbeddedFile")]
    [DataMember]
    public List<EmbeddedFile> EmbeddedFiles { get; set; } = new();

    /// <summary>
    /// نوع بخش (مثلاً سوال، راهنما، منبع).
    /// اگر از نوع سوال باشد، باید دارای متن باشد.
    /// </summary>
    [XmlAttribute("PassageType")]
    [DataMember]
    public PassageType PassageType { get; set; }

    /// <summary>
    /// ترتیب نمایش یا پخش این بخش در سوال.
    /// </summary>
    [XmlAttribute("DisplayOrder")]
    [DataMember]
    public int DisplayOrder { get; set; }

    /// <summary>
    /// آیا هنگام پخش این بخش، زمان آزمون متوقف شود؟
    /// </summary>
    [XmlAttribute("StopTimer")]
    [DataMember]
    public bool IsStopingTime { get; set; }

    /// <summary>
    /// اطلاعات اضافی مرتبط با این بخش (مثلاً تنظیمات صوت، زیرنویس...).
    /// </summary>
    [XmlElement("Properties")]
    [DataMember]
    public  PassageProperties Properties { get; set; }

    /// <summary>
    /// اعتبارسنجی ساختار بخش برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (PassageType == PassageType.Question && string.IsNullOrWhiteSpace(Text))
            errors.Add(new("Text", "Missing", "Question-type passage must contain text."));

        return errors;
    }
}

