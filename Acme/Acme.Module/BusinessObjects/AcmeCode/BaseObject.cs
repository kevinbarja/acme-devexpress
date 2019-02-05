using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Acme.Module.BusinessObjects.acme
{

    public partial class BaseObject
    {
        public BaseObject(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        public abstract new class Fields
        {
            protected Fields() { }

            public static OperandProperty Id { get { return new OperandProperty("Id"); } }
            public static OperandProperty Name { get { return new OperandProperty("Name"); } }

        }
    }

}
