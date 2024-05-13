# Documentação dos KPIs - MultiStore Sales Analysis

---

## 1. Total Sales (Vendas Totais):

- **Descrição:** Este KPI mede o total de vendas realizadas pela MultiStore em um determinado período de tempo.
- **Fórmula:** `Total Sales = SUM('stage Multistore'[Sales])`
- **Objetivo/Meta:** Aumentar as vendas em 10% em relação ao mesmo período do ano anterior.
- **Análise:** Este KPI fornece uma visão geral do desempenho de vendas da MultiStore e ajuda a avaliar o progresso em direção às metas de receita.

## 2. Total Profit (Lucro Total):

- **Descrição:** Este KPI mede o lucro total gerado pela MultiStore em um determinado período de tempo.
- **Fórmula:** `Total Profit = SUM('stage Multistore'[Profit])`
- **Objetivo/Meta:** Aumentar o lucro em 15% em relação ao mesmo período do ano anterior.
- **Análise:** O Total Profit ajuda a avaliar a eficácia das estratégias de precificação e operacionais da MultiStore, fornecendo uma visão do desempenho financeiro geral.

## 3. Quantity of Products Sold (Quantidade de Produtos Vendidos):

- **Descrição:** Este KPI mede o número total de produtos vendidos pela MultiStore em um determinado período de tempo.
- **Fórmula:** `Quantity Sold = SUM('stage Multistore'[Quantity])`
- **Objetivo/Meta:** Aumentar a quantidade de produtos vendidos em 5% em relação ao mesmo período do ano anterior.
- **Análise:** A Quantity of Products Sold ajuda a entender a demanda dos produtos da MultiStore e identificar quais produtos são os mais populares entre os clientes.

## 4. Average Discount Rate (Taxa de Desconto Média):

- **Descrição:** Este KPI mede a taxa média de desconto aplicada às vendas da MultiStore em um determinado período de tempo.
- **Fórmula:** `Average Discount Rate = AVERAGE('stage Multistore'[Discount])`
- **Objetivo/Meta:** Manter a taxa de desconto média abaixo de 10% para garantir a lucratividade.
- **Análise:** A Average Discount Rate ajuda a avaliar a eficácia das estratégias de precificação e promoção da MultiStore, identificando se os descontos estão sendo aplicados de forma eficiente.

### Observações Adicionais:

- **Segmentação dos KPIs por Dimensões:** Todos os KPIs podem ser segmentados por dimensões como cliente, produto, tempo e localização para uma análise mais detalhada.
- **Metodologia de Cálculo:** Os KPIs são calculados com base nos dados da tabela 'stage Multistore' e podem ser acompanhados ao longo do tempo para monitorar o desempenho da MultiStore.

