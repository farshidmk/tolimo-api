using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// یک بخش از دفترچه آزمون.
/// شامل عنوان، نوع بخش، ترتیب نمایش، زمان اختصاصی، سوالات، و تنظیمات فرم.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "BookletSection")]
public class BookletSection : DataPrimitive, IValidatable
{
    public Guid SectionId { get; set; }
    public string BookletCode { get; set; }

    /// <summary>
    /// عنوان بخش برای نمایش به داوطلب یا در گزارش‌ها.
    /// </summary>
    [XmlAttribute("Title")]
    [DataMember]
    public string Title { get; set; } = "";

    /// <summary>
    /// نوع بخش آزمون (مثلاً Reading، Writing، System).
    /// </summary>
    [XmlAttribute("SectionType")]
    [DataMember]
    public SectionType SectionType { get; set; }

    /// <summary>
    /// ترتیب نمایش بخش در دفترچه.
    /// </summary>
    [XmlAttribute("DisplayOrder")]
    [DataMember]
    public int DisplayOrder { get; set; }

    /// <summary>
    /// زمان اختصاصی برای این بخش از آزمون.
    /// </summary>
    [XmlAttribute("SectionDuration")]
    [DataMember]
    public TimeSpan? SectionDuration { get; set; }

    /// <summary>
    /// آیا پاسخ دادن به سوالات این بخش اجباری است؟
    /// </summary>
    [XmlAttribute("IsForcedToAnswer")]
    [DataMember]
    public bool IsForcedToAnswer { get; set; }

    /// <summary>
    /// آیا پاسخها قابل ویرایش هستند؟
    /// </summary>
    [XmlAttribute("AreAnswersEditable")]
    [DataMember]
    public bool AreAnswersEditable { get; set; }

    /// <summary>
    /// حداقل تعداد سوالی که باید پاسخ دهد
    /// </summary>
    [XmlAttribute("MinRequiredAnswers")]
    [DataMember]
    public int MinRequiredAnswers { get; set; }

    /// <summary>
    /// حداکثر تعداد سوالی که میتواند پاسخ دهد
    /// </summary>
    [XmlAttribute("MaxAllowedAnswers")]
    [DataMember]
    public int MaxAllowedAnswers { get; set; }
    
    /// <summary>
    /// لیست سوالات موجود در این بخش.
    /// </summary>
    [XmlElement("Question")]
    [DataMember]
    public List<BookletQuestion> Questions { get; set; } = new();

    /// <summary>
    /// اجزای فرم مورد نیاز برای نمایش یا تعامل در این بخش.
    /// </summary>
    [XmlElement("FormObject")]
    [DataMember]
    public List<FormObject> FormObjects { get; set; } = new();

    /// <summary>
    /// مرتب‌سازی سوالات بر اساس ترتیب نمایش.
    /// </summary>
    public void Reorganize()
    {
        Questions = Questions.Where(q => q != null).OrderBy(q => q.DisplayOrder).ToList();
    }

    /// <summary>
    /// اعتبارسنجی ساختار بخش برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (string.IsNullOrWhiteSpace(Title))
            errors.Add(new("Title", "Empty", "Section title is required."));

        if (Questions.Count == 0)
            errors.Add(new("Questions", "Empty", "Section must contain at least one question."));

        return errors;
    }
}
