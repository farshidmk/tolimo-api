using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// یک گزینه در لیست پاسخ‌های سوال.
/// شامل متن نمایشی، شماره پاسخ‌نامه، و ترتیب نمایش.
/// قابل استفاده در سوالات چندگزینه‌ای، شنیداری، یا تعاملی.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "Choice")]
public class Choice : DataPrimitive, IValidatable
{
    /// <summary>
    /// شماره گزینه در پاسخ‌نامه.
    /// برای ثبت پاسخ داوطلب و ارزیابی.
    /// </summary>
    [XmlAttribute("Id")]
    [DataMember]
    public byte Id { get; set; }

    /// <summary>
    /// متن نمایشی گزینه.
    /// می‌تواند شامل متن، تصویر، یا صوت باشد.
    /// </summary>
    [XmlAttribute("Text")]
    [DataMember]
    public string Text { get; set; } = "";

    /// <summary>
    /// ترتیب نمایش گزینه.
    /// اگر مقدار داشته باشد، گزینه‌ها بر اساس آن مرتب می‌شوند؛ در غیر این‌صورت به‌صورت تصادفی.
    /// </summary>
    [XmlAttribute("Order")]
    [DataMember]
    public byte Order { get; set; }

    /// <summary>
    /// اعتبارسنجی ساختار گزینه برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(Text))
            errors.Add(new("Text", "Empty", "Choice text is required."));

        return errors;
    }
}