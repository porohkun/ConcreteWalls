using HugsLib;
using HugsLib.Settings;
using RimWorld;
using Verse;

namespace ConcreteWalls
{
    public class ConcreteWallsMod : ModBase
    {
        //public override string ModIdentifier => "ConcreteWalls";

        private SettingHandle<bool> _allowEmbrasures;

        public override void DefsLoaded()
        {
            _allowEmbrasures = Settings.GetHandle("allowEmbrasures",
                "ConcreteWalls_AllowEmbrasuresName".Translate(),
                "ConcreteWalls_AllowEmbrasuresDesc".Translate(),
                true);
            ChangeDefs();
        }

        public override void SettingsChanged()
        {
            base.SettingsChanged();
            ChangeDefs();
        }

        private void ChangeDefs()
        {
            var embrasureThingDef = ThingDef.Named("Embrasure");
            embrasureThingDef.designationCategory = _allowEmbrasures ? DesignationCategoryDefOf.Structure : null;
            DesignationCategoryDefOf.Structure.ResolveReferences();
        }
    }
}
