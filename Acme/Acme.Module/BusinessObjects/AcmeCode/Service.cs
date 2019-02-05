using DevExpress.Xpo;
using DevExpress.Persistent.Base;

namespace Acme.Module.BusinessObjects.acme
{
    [DefaultClassOptions]
    public partial class Service
    {
        public Service(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
