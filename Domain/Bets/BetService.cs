using Infraestructure.Common.Constants;
using Infraestructure.Model.Models;
using Infraestructure.Repository.Entities;
using Infraestructure.Repository.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bets
{
    public class BetService : IBetService
    {
        private readonly IRulesRepository _rulesRepository;

        public BetService(IRulesRepository rulesRepository)
        {
            _rulesRepository = rulesRepository;
        }

        async public Task<BetCalculateDTO> BetCalculate(List<ParticipantDTO> participants)
        {
            var betCalculate = new BetCalculateDTO();
            var participantsCalculate = new List<ParticipantDTO>();
            var rules = await _rulesRepository.Get();
            betCalculate.WinnerColor = WinnerColor();
            betCalculate.WinnerNumber = WinnerNumber(rules.BoxesNumber);
            foreach (var participant in participants)
            {
                if (participant.BetType == GenericConstant.Color && participant.BetColor.ToLower() == betCalculate.WinnerColor)
                {
                    participant.MoneyEarned = CalculateMoneyEarnedColor(participant.BetMoney, rules.MultipleEarningColor);
                    participant.IsWinner = true;
                }
                if(participant.BetType == GenericConstant.Numero && participant.BetNumber == betCalculate.WinnerNumber)
                {
                    participant.MoneyEarned = CalculateMoneyEarnedNumber(participant.BetMoney, rules.MultipleEarningNumber);
                    participant.IsWinner = true;
                }
                participantsCalculate.Add(participant);
            }
            betCalculate.Participants = participantsCalculate;

            return betCalculate;
        }

        async public Task<List<string>> BetValidate(ParticipantDTO participant)
        {
            var rules = await _rulesRepository.Get();
            var errors = new List<string>();
            if (participant.BetType == GenericConstant.Color)
            {
                errors.AddRange(ValidateColor(participant.BetColor));
            }
            else
            {
                errors.AddRange(ValidateNumber(participant.BetNumber, rules));
            }
            if (participant.BetMoney > rules.MaxBetMoney || participant.BetMoney <= 0)
                errors.Add(string.Format(ErrorMessageConstant.BetMoneyError, rules.MaxBetMoney));

            return errors;
        }

        private static List<string> ValidateColor(string betColor)
        {
            var errors = new List<string>();
            if (betColor.ToLower() != GenericConstant.Colors[0] && betColor.ToLower() != GenericConstant.Colors[1])
                errors.Add(ErrorMessageConstant.BetColorError);

            return errors;
        }

        private static List<string> ValidateNumber(int betNumber, Rules rules)
        {
            var errors = new List<string>();
            if (betNumber < 0 || betNumber > rules.BoxesNumber)
                errors.Add(string.Format(ErrorMessageConstant.BetNumberError, rules.BoxesNumber));

            return errors;
        }

        private static int WinnerNumber(int boxesNumber)
        {
            Random random = new Random();
            int WinnerNumber = random.Next(0, boxesNumber);

            return WinnerNumber;
        }

        private static double CalculateMoneyEarnedNumber(double betMoney, double MultipleEarningNumber) => betMoney * MultipleEarningNumber;
        private static double CalculateMoneyEarnedColor(double betMoney, double MultipleEarningColor) => betMoney * MultipleEarningColor;

        private static string WinnerColor()
        {
            Random random = new Random();
            int WinnerColorIndex = random.Next(0, GenericConstant.Colors.Length);
            string WinnerColor = GenericConstant.Colors[WinnerColorIndex];

            return WinnerColor;
        }
    }
}
