using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillNet.Domain.Common.Models;

namespace SkillNet.Domain.Recipes.Models.Memberships
{
    internal class Membership : Entity<int>
    {

        internal Membership(Group group, Member member, decimal monthlyFee)
        {
            this.Group = group;
            this.Member = member;
            this.MonthlyFee = monthlyFee;
            this.JoinedDate = DateTime.UtcNow;
            this.NextPaymentDueDate = JoinedDate.AddMonths(1);
            IsPaymentUpToDate = false;
        }
        public Group Group { get; private set; }
        public Member Member { get; private set;  }
        public DateTime JoinedDate { get; private set; }
        public DateTime NextPaymentDueDate { get; private set; }
        public decimal MonthlyFee { get; private set; }
        public bool IsPaymentUpToDate { get; private set; }
    }
}
