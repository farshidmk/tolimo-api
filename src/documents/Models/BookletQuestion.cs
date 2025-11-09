using NOET.UET.Domain.Booklet.Enums;
using NOET.UET.Shared.Models.Primitives;
using NOET.UET.Shared.Validation.Interfaces;
using NOET.UET.Shared.Validation.Models;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NOET.UET.Domain.Booklet.Models;

/// <summary>
/// یک سوال در دفترچه آزمون.
/// شامل متن، منابع، گزینه‌ها، زمان‌بندی، و تنظیمات نمایشی.
/// این مدل قابل استفاده در تولید، اجرا، و ارزیابی آزمون است.
/// </summary>
[Serializable]
[DataContract]
[XmlType(TypeName = "BookletQuestion")]
public class BookletQuestion : DataPrimitive, IValidatable
{
    /// <summary>
    /// شناسه یکتا برای سوال در آزمون.
    /// </summary>
    [XmlAttribute("QuestionId")]
    [DataMember]
    public Guid QuestionId { get; set; }
    
    [XmlAttribute("SectionId")]
    [DataMember]
    public Guid SectionId { get; set; }

    /// <summary>
    /// ترتیب نمایش سوال در بخش.
    /// </summary>
    [XmlAttribute("DisplayOrder")]
    [DataMember]
    public int DisplayOrder { get; set; }

    /// <summary>
    /// اشیای فرم مرتبط با سوال (مثلاً دکمه‌ها، برچسب‌ها).
    /// اگر خالی باشد، از بخش بالادست تبعیت می‌کند.
    /// </summary>
    [XmlElement("FormObject")]
    [DataMember]
    public List<FormObject> FormObjects { get; set; } = [];

    /// <summary>
    /// آیا هنگام نمایش این سوال، تایمر بخش متوقف شود؟
    /// </summary>
    [XmlAttribute("StopSectionTimer")]
    [DataMember]
    public bool StopSectionTimer { get; set; }

    /// <summary>
    /// پس از چند ثانیه توقف، سوال بعدی به‌صورت خودکار نمایش داده شود.
    /// اگر صفر باشد، منتظر تعامل کاربر می‌ماند.
    /// </summary>
    [XmlAttribute("NextAfterSeconds")]
    [DataMember]
    public short NextAfterSeconds { get; set; }

    /// <summary>
    /// نوع سوال (مثلاً چندگزینه‌ای، تشریحی، شنیداری...).
    /// </summary>
    [XmlAttribute("QuestionClass")]
    [DataMember]
    public QuestionKind QuestionType { get; set; }

    /// <summary>
    /// دستورالعمل کلی سوال برای نمایش به داوطلب.
    /// می‌تواند خالی باشد.
    /// </summary>
    [XmlAttribute("Direction")]
    [DataMember]
    public string Direction { get; set; } = "";

    /// <summary>
    /// توضیحات یا اطلاعات تکمیلی برای داوطلب.
    /// می‌تواند خالی باشد.
    /// </summary>
    [XmlElement("Comment")]
    [DataMember]
    public List<Comment>? Comments { get; set; }

    /// <summary>
    /// لیست گزینه‌های سوال (برای سوالات چندگزینه‌ای).
    /// می‌تواند خالی باشد.
    /// </summary>
    [XmlElement("ChoiceList")]
    [DataMember]
    public ChoiceList? ChoiceList { get; set; } 

    /// <summary>
    /// منابع وابسته به سوال (متن، تصویر، صوت).
    /// متن اصلی سوال نیز در این لیست قرار می‌گیرد.
    /// باید دارای مقدار باشد.
    /// </summary>
    [XmlElement("Passage")]
    [DataMember]
    public List<Passage> Passages { get; set; } = [];

    /// <summary>
    /// آیا پاسخ دادن به این سوال اجباری است؟
    /// </summary>
    [XmlAttribute("IsForcedToAnswer")]
    [DataMember]
    public bool IsForcedToAnswer { get; set; }

    /// <summary>
    /// زمان اختصاصی برای مشاهده یا پاسخ‌دهی به سوال (بر حسب ثانیه).
    /// می‌تواند صفر باشد.
    /// </summary>
    [XmlAttribute("QuestionTime")]
    [DataMember]
    public short QuestionTime { get; set; }

    /// <summary>
    /// زمان اختصاصی برای مشاهده بدون پاسخ‌دهی به سوال (بر حسب ثانیه).
    /// می‌تواند صفر باشد.
    /// براس والاتی استفاده میشود که نیاز هست به دواطلب فرصت آمادگی داده شود. مانند سوالات گفتاری
    /// </summary>
    [XmlAttribute("WaitingTime")]
    [DataMember]
    public short WaitingTime { get; set; }

    /// <summary>
    /// مرتب‌سازی منابع وابسته بر اساس ترتیب نمایش.
    /// </summary>
    public void Reorganize()
    {
        Passages = [.. Passages.OrderBy(p => p.DisplayOrder)];
    }

    /// <summary>
    /// اعتبارسنجی ساختار سوال برای اطمینان از کامل بودن داده‌ها.
    /// </summary>
    public List<ValidationError> Validate()
    {
        var errors = new List<ValidationError>();

        if (Passages.Count == 0)
            errors.Add(new(nameof(Passages), "Empty", "Question must contain at least one passage."));

        return errors;
    }
}
