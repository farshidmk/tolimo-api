using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models
;
/// <summary>
/// لیست گزینه‌های یک سوال.
/// شامل تنظیمات نمایش، ترتیب، و نوع گزینه‌ها.
/// قابل استفاده در سوالات چندگزینه‌ای، شنیداری، یا ترکیبی.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "ChoiceList")]
public class ChoiceList : DataPrimitive, IValidatable
{
    /// <summary>
    /// آیا گزینه‌ها با تأخیر نمایش داده شوند؟
    /// معمولاً در سوالات شنیداری برای جلوگیری از پیش‌نمایش استفاده می‌شود.
    /// </summary>
    [XmlAttribute("NotShowImmediately")]
    [DataMember]
    public bool NotShowImmediately { get; set; }

    /// <summary>
    /// لیست گزینه‌ها برای انتخاب توسط داوطلب.
    /// می‌تواند شامل متن، تصویر، یا صوت باشد.
    /// </summary>
    [XmlElement("Choice")]
    [DataMember]
    public List<Choice> Choices { get; set; } = new();

    /// <summary>
    /// نوع لیست گزینه‌ها (مثلاً تک‌گزینه‌ای، چندگزینه‌ای، Drag & Drop).
    /// برای کنترل رفتار ارزیابی و نمایش.
    /// </summary>
    [XmlAttribute("ChoiceMode")]
    [DataMember]
    public AnswerSelectionMode ChoiceMode { get; set; }

    /// <summary>
    /// آیا گزینه‌ها باید به ترتیب مشخص‌شده نمایش داده شوند؟
    /// اگر false باشد، ممکن است به‌صورت تصادفی یا بر اساس منطق دیگر مرتب شوند.
    /// </summary>
    [XmlAttribute("IsOrdered")]
    [DataMember]
    public bool IsOrdered { get; set; }

    /// <summary>
    /// اعتبارسنجی ساختار لیست گزینه‌ها برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (Choices.Count == 0)
            errors.Add(new("Choices", "Empty", "Choice list must contain at least one option."));

        return errors;
    }
}
