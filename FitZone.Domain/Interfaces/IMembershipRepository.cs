
using FitZone.Domain.Models.Entities;

namespace FitZone.Domain.Interfaces
{
    public interface IMembershipRepository
    {
        void AddMembership(Membership membership);

        Membership GetActiveMembershipByMemberId(int memberId);

        void UpdateMembership(Membership membership);
    }
}
