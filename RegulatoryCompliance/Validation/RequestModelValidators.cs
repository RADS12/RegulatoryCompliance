using FluentValidation;
using Common.Models;

namespace RegulatoryCompliance.Validation
{
    public class HighCostTestInputValidator : AbstractValidator<HighCostTestInput>
    {
        public HighCostTestInputValidator()
        {
            RuleFor(x => x.LoanNumber).GreaterThan(0);
            RuleFor(x => x.LoanAmount).GreaterThan(0);
            RuleFor(x => x.TermYears).GreaterThan(0);
            RuleFor(x => x.InterestRate).GreaterThan(0);
            RuleFor(x => x.HasBalloonPayment).Equal(false)
                .WithMessage("High Cost loans can't have balloon payments.");
            RuleFor(x => x.HasNegativeAmortization).Equal(false)
                .WithMessage("High Cost loans can't have negative amortization.");
        }
    }

    public class PointsAndFeesTestInputValidator : AbstractValidator<PointsAndFeesTestInput>
    {
        public PointsAndFeesTestInputValidator()
        {
            RuleFor(x => x.LoanNumber)
                .GreaterThan(0)
                .WithMessage("LoanNumber must be greater than 0.");
            RuleFor(x => x.PointsPaid)
                .GreaterThanOrEqualTo(0)
                .WithMessage("PointsPaid must be zero or positive.");
            RuleFor(x => x.OtherFees)
                .GreaterThanOrEqualTo(0)
                .WithMessage("OtherFees must be zero or positive.");
            RuleFor(x => x.APR)
                .GreaterThanOrEqualTo(0)
                .WithMessage("APR must be zero or positive.");
        }
    }

    public class SafeHarborTestInputValidator : AbstractValidator<SafeHarborTestInput>
    {
        public SafeHarborTestInputValidator()
        {
            RuleFor(x => x.LoanNumber)
                .GreaterThan(0)
                .WithMessage("LoanNumber must be greater than 0.");
            RuleFor(x => x.HasPrepaymentPenalty)
                .NotNull()
                .WithMessage("HasPrepaymentPenalty must be specified.");
        }
    }

    public class StateRegulatoryTestInputValidator : AbstractValidator<StateRegulatoryTestInput>
    {
        public StateRegulatoryTestInputValidator()
        {
            RuleFor(x => x.LoanNumber)
                .GreaterThan(0)
                .WithMessage("LoanNumber must be greater than 0.");
            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("State must not be empty.");
        }
    }
}
