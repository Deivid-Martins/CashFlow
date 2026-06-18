using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("Title is required.");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var dateIsValid = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (dateIsValid > 0)
        {
            throw new ArgumentException("Expense date cannot be in the future.");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);
        if(paymentTypeIsValid == false)
        {
            throw new ArgumentException("Invalid payment type.");
        }
    }
}
