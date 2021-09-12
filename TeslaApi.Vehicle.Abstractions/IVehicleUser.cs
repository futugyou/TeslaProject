using TeslaApi.Contract.User;

namespace TeslaApi.Vehicle.Abstractions
{
    public interface IVehicleUser
    {
        Task<PowerwallOrderSessionDataResponse> GetPowerwallOrderSessionData(int id, string token);
        Task<OnboardingExperienceResponse> GeOnboardingExperience(int id, string token);
        Task<ServiceSelfSchedulingEligibilityResponse> GetServiceSelfSchedulingEligibility(int id, string token);
        Task<ReferralDataResponse> GetReferralData(int id, string token);
        Task<RoadsideAssistanceDataResponse> GetRoadsideAssistanceData(int id, string token);
    }
}
