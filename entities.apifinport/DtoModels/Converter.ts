export interface UserOperationHistoryEntity {
    id: number;
    userId: number;
    buyPrice: number;
    conversionUSD: number;
    amount: number;
    totalConverted: number;
    total: number;
    feeValue: number;
}

export interface ProductsEntity {
    id: number;
    abbv: string;
    company: string;
    index_traded: string;
    currency: string;
    current_price: number;
    Change: number;
    sector: string;
    industry: string;
    market_cap: string;
    href: string;
}

export interface ExchangeEntity {
    id: number;
    symbol: string;
    designation: string;
}

