using Advent.FinalProject.Entities.DTOs;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.Core.V1
{
    public class StripeCore
    {
        public StripeCore()
        {
            StripeConfiguration.ApiKey = "sk_test_51LYcEOKjKR5qX1uUGq2m4aQ06jAaVrXQKQ6ZT2OQn6GCCJaCT6Z2OGS7aAdlfwLJlOY0xEjCfQvh3qhv8wOzOpol004PgV0wrJ";
        }

        public PaymentMethod CreatePaymentMethod(CardDto card, string idCustomer)
        {
            var options = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardOptions
                {
                    Number = card.CardNumber,
                    ExpMonth = card.ExpirationMonth,
                    ExpYear = card.ExpirationYear,
                    Cvc = card.Cvv,
                },
            };
            var service = new PaymentMethodService();
            var result = service.Create(options);
            AttachPaymentMethodToCustomer(result.Id, idCustomer);
            return result;
        }

        public PaymentIntent PlacePayment(string methodToken, int amount, string customerToken, string currency = "usd")
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount * 100,
                Currency = currency,
                PaymentMethod = methodToken,
                Customer = customerToken,
                Confirm = true
            };
            var service = new PaymentIntentService();
            return service.Create(options);
        }

        public string CreateCustomer(string name, string email)
        {
            var options = new CustomerCreateOptions
            {
                Name = name,
                Email = email
            };
            var service = new CustomerService();
            return service.Create(options).Id;
        }

        private void AttachPaymentMethodToCustomer(string idPaymentMethod, string idCustomer)
        {
            var options = new PaymentMethodAttachOptions
            {
                Customer = idCustomer,
            };
            var service = new PaymentMethodService();
            service.Attach(idPaymentMethod, options);
        }
    }
}
