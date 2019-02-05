using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{

    public partial class Department
    {
        public Department(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
