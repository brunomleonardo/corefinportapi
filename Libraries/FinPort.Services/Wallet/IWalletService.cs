using FinPort.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinPort.Services.Wallet
{
    public interface IWalletService
    {
        Wallets InsertWallet(Wallets Entity);
        int GenerateId();
    }
}
