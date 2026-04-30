////// script.js
////// صفحه با هر بار ارسال فرم رفرش می‌شود (بدون Ajax)
////// پیام جدید از URL خوانده شده و به چت اضافه می‌شود

////$(document).ready(function () {

////    // تابع نمایش پیام‌ها
////    function renderMessages() {
        

////        // اسکرول به پایین
////        const container = document.getElementById("messagesArea");
////        if (container) container.scrollTop = container.scrollHeight;
////    }

////    // جلوگیری از XSS
////    function escapeHtml(str) {
////        return str.replace(/[&<>]/g, function (m) {
////            if (m === "&") return "&amp;";
////            if (m === "<") return "&lt;";
////            if (m === ">") return "&gt;";
////            return m;
////        }).replace(/[\uD800-\uDBFF][\uDC00-\uDFFF]/g, function (c) {
////            return c;
////        });
////    }

////    // افزودن پیام جدید (فقط حافظه موقت - بعد از رفرش از url خوانده می‌شود)
////    function addMessageLocally(sender, text, time, date) {
////        messages.push({ sender: sender, text: text, time: time, date: date });
////        renderMessages();
////    }

////    // گرفتن زمان و تاریخ فعلی
////    function getCurrentTime() {
////        const now = new Date();
////        const hour = now.getHours().toString().padStart(2, '0');
////        const minute = now.getMinutes().toString().padStart(2, '0');
////        return `${hour}:${minute}`;
////    }

////    function getCurrentDate() {
////        return new Date().toLocaleDateString('fa-IR');
////    }

////    // خواندن پیام از URL و localStorage در لود صفحه
////    function loadMessagesFromStorage() {
////        const stored = localStorage.getItem("chatMessages");
////        if (stored) {
////            try {
////                const parsed = JSON.parse(stored);
////                if (Array.isArray(parsed) && parsed.length > 0) {
////                    messages = parsed;
////                }
////            } catch (e) { }
////        }

////        // اضافه کردن پیام ارسالی از طریق GET (اگر وجود داشته باشد)
////        const urlParams = new URLSearchParams(window.location.search);
////        const msgFromUrl = urlParams.get("msg");
////        if (msgFromUrl && msgFromUrl.trim() !== "") {
////            // چک کنیم آخرین پیام تکراری نباشد
////            const lastMsg = messages[messages.length - 1];
////            if (!lastMsg || lastMsg.text !== msgFromUrl) {
////                const newUserMsg = {
////                    sender: "user",
////                    text: msgFromUrl,
////                    time: getCurrentTime(),
////                    date: getCurrentDate()
////                };
////                messages.push(newUserMsg);

////                // پاسخ خودکار پشتیبانی
////                const autoReply = {
////                    sender: "support",
////                    text: "✅ پیام شما ثبت شد. به زودی پاسخگو خواهیم بود.",
////                    time: getCurrentTime(),
////                    date: getCurrentDate()
////                };
////                messages.push(autoReply);

////                // ذخیره در localStorage
////                localStorage.setItem("chatMessages", JSON.stringify(messages));
////            }
////            // حذف پارامتر از URL بدون رفرش (تاریخچه تمیز)
////            window.history.replaceState({}, document.title, window.location.pathname);
////        }

////        renderMessages();
////    }

////    // بارگذاری اولیه
////    loadMessagesFromStorage();

////    // ریست کردن localStorage (اختیاری برای تست - می‌توانید حذف کنید)
////    // localStorage.removeItem("chatMessages");

////});