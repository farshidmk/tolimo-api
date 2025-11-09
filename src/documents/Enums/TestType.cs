namespace NOET.UET.Domain.Booklet.Enums;

/// <summary>
/// نوع آزمون.
/// برای تعیین رفتار دفترچه و ارزیابی.
/// </summary>
public enum TestType
{
    Standard = 0,
    Adaptive = 1,
    Practice = 2,
    Diagnostic = 3
}


///// <summary>
///// نوع آزمون.
///// برای تعیین رفتار دفترچه، ارزیابی، و نمایش.
///// </summary>
//[Serializable]
//[DataContract]
//public enum TestType : byte
//{
//    /// <summary>
//    /// آزمون تولیمو (آزمون زبان رسمی).
//    /// </summary>
//    [EnumMember]
//    [XmlEnum("3")]
//    Tolimo = 3
//}
