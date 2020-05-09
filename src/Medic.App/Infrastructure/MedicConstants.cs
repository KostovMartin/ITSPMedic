﻿namespace Medic.App.Infrastructure
{
    internal class MedicConstants
    {
        internal static readonly string[] AllowedLanguages = { "bg", "en" };
        internal const string DefaultLanguage = "en";
        internal const string LanguageCookieName = "lang";
        internal const int LanguageCookieSpanInDays = 365;
        internal const string AdministratorName = "administratorName";
        internal const string AdministratorEmail = "administratorEmail";
        internal const string AdministratorPassword = "administratorPassword";
    }
}