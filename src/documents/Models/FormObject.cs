using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// شیء فرم در دفترچه آزمون.
/// می‌تواند نمایانگر یک کنترل نمایشی، ورودی، یا عنصر تعاملی باشد.
/// در بخش‌هایی از آزمون برای نمایش، تعامل یا جمع‌آوری داده استفاده می‌شود.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "FormObject")]
public class FormObject : DataPrimitive, IValidatable
{
    /// <summary>
    /// وضعیت فعلی شیء فرم (فعال، غیرفعال، مخفی...).
    /// برای کنترل نمایش یا تعامل در زمان اجرا.
    /// </summary>
    [XmlAttribute("State")]
    [DataMember]
    public FormObjectState State { get; set; }

    /// <summary>
    /// عنوان یا برچسب نمایشی برای شیء فرم.
    /// معمولاً برای نمایش به داوطلب یا در گزارش‌ها استفاده می‌شود.
    /// </summary>
    [XmlAttribute("Label")]
    [DataMember]
    public required string Label { get; set; }

    /// <summary>
    /// نوع شیء فرم (مثلاً دکمه، ورودی متن، تصویر، جدول...).
    /// برای تعیین رفتار و رندر مناسب در کلاینت.
    /// </summary>
    [XmlAttribute("Type")]
    [DataMember]
    public FormObjectType FormObjectType { get; set; }

    /// <summary>
    /// اعتبارسنجی شیء فرم برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(Label))
            errors.Add(new("Label", "Empty", "Form object label is required."));

        return errors;
    }
}
