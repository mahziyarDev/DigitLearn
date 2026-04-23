using Ganss.Xss;

namespace Common.Application.SecurityUtil
{
    public static class XssSecurity
    {
        //این کد یک متد الحاقی (Extension Method) است که از کتابخانه HtmlSanitizer برای پاک‌سازی متن‌های HTML ورودی استفاده می‌کند. کاربرد اصلی آن جلوگیری از حملات تزریق کد (Cross-Site Scripting - XSS) است
        public static string SanitizeText(this string text)
        {
            var htmlSanitizer = new HtmlSanitizer
            {
                //اگر تگی حذف شود (مثلاً یک تگ خطرناک)، محتوای داخل آن تگ حفظ می‌شود و فقط تگ بیرونی پاک می‌گردد.
                KeepChildNodes = true,
                // به استفاده از ویژگی‌های data-* (مانند data-id یا data-role) در المان‌های HTML اجازه می‌دهد.
                AllowDataAttributes = true
            };

            return htmlSanitizer.Sanitize(text);
        }
    }

}
