using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{

    public partial class UserService
    {
        public UserService(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
