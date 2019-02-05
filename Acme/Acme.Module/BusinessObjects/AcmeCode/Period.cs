using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{

    public partial class Period
    {
        public Period(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
