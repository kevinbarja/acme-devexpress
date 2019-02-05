using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{
    public partial class BusinessUnit
    {
        public BusinessUnit(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
