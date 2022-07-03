using flanne;

namespace Buddy;

internal static class LocalizationUtils
{
    internal struct LocalizationValues
    {
        public string EN;
        public string JP;
        public string CH;
        public string BR;
        public string TC;
        public string RU;
        public string SP;
        public string GR;
        public string PL;
        public string IT;
        public string TR;
        public string FR;
    }

    internal static void AddKey(string key, LocalizationValues values)
    {
        LocalizationSystem.localizedEN.Add(key, values.EN);
        LocalizationSystem.localizedJP.Add(key, values.JP);
        LocalizationSystem.localizedCH.Add(key, values.CH);
        LocalizationSystem.localizedBR.Add(key, values.BR);
        LocalizationSystem.localizedTC.Add(key, values.TC);
        LocalizationSystem.localizedRU.Add(key, values.RU);
        LocalizationSystem.localizedSP.Add(key, values.SP);
        LocalizationSystem.localizedGR.Add(key, values.GR);
        LocalizationSystem.localizedPL.Add(key, values.PL);
        LocalizationSystem.localizedIT.Add(key, values.IT);
        LocalizationSystem.localizedTR.Add(key, values.TR);
        LocalizationSystem.localizedFR.Add(key, values.FR);
    }
}
