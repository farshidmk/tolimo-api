using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;
/// <summary>
/// یک توضیح یا پیام متنی مرتبط با سوال یا فرم آزمون.
/// می‌تواند شامل راهنما، هشدار، یا اطلاعات تکمیلی برای داوطلب باشد.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "Comment")]
public class Comment : DataPrimitive, IValidatable
{
    /// <summary>
    /// متن توضیح یا پیام نمایشی.
    /// می‌تواند شامل راهنما، هشدار، یا اطلاعات تکمیلی باشد.
    /// </summary>
    [XmlAttribute("Text")]
    [DataMember]
    public string Text { get; set; } = "";

    /// <summary>
    /// نوع توضیح (مثلاً راهنما، هشدار، پیام سیستمی...).
    /// برای کنترل رفتار نمایش یا ارزیابی.
    /// </summary>
    [XmlAttribute("CommentType")]
    [DataMember]
    public CommentType CommentType { get; set; }

    /// <summary>
    /// اعتبارسنجی ساختار توضیح برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(Text))
            errors.Add(new("Text", "Empty", "Comment text is required."));

        return errors;
    }
}
