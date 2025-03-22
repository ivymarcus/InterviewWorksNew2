# InterviewWorksNew2
WebApi
---
### 資料庫名稱: supergemma
### 資料表: dbo.Category
| 資料行名稱 | 資料類型 | 允許null |
| :-- | :-- |:--:|
| CategoryID  | int | |
| CategoryName  | nvarchar(30) |  |

### 資料表: dbo.Product
| 資料行名稱 | 資料類型 | 允許null |
| :-- | :-- |:--:|
| ProductID | int |  |
| ProductName | nvarchar(50) |  |
| UnitPrice | int |  |
| Discount | decimal(2, 2) |  |
| CategoryID | int |  |
| Explain | nvarchar(MAX)|  |

- - -

### HttpPost
#### Requset Json
| 欄位 | 型態 | 字數限制 | 說明 |
| :-- | :-- | :-- |:--|
| Status | string | 1 | N: 新增；U: 更新；D: 刪除 |
| ProductName | string | 50 | 商品品號 |
| Explain | string | | 商品名稱 |
| ItemCategory | string | 30 | 類別名稱 |
| UnitPrice | int | | 商品單價 |
| Discount | float | decimal(2, 2) | 折扣 |

```json
{
    "Status": "N",   /* N: 新增；U: 更新；D: 刪除 */
    "ProductName": "A001",
    "Explain": "蘋果",
    "ItemCategory": "B",
    "UnitPrice": 60,
    "Discount": 0.00
}
```

#### Response Json
| 欄位 | 型態 | 說明 |
| :-- | :-- |:--|
| Status | int | 1: 成功；2: 失敗 |
| Message | string | 訊息 |

##### 成功訊息:
```json
{
    "Status": 1,
    "Message": "更新-成功"
}
```

##### 失敗訊息:
```json
{
    "Status": 2,
    "Message": "此商品已存在"
}
```

- - -

### HttpGet
#### Response Json
| 欄位 | 型態 | 說明 |
| :-- | :-- |:--|
| Status | int | 1: 成功；2: 失敗 |
| Message | nvarchar(MAX) | 訊息 |
| ProductModels | List<> | 商品資訊 |

```json
{
    "Status": 1,
    "Message": "Success",
    "ProductModels": [
        {
            "ProductName": "A004",
            "Explain": "生活紅",
            "CategoryName": "B",
            "UnitPrice": 60,
            "Discount": 0.0
        },
        {
            "ProductName": "A003",
            "Explain": "柳丁",
            "CategoryName": "A",
            "UnitPrice": 200,
            "Discount": 0.5
        },
        {
            "ProductName": "A002",
            "Explain": "香蕉",
            "CategoryName": "B",
            "UnitPrice": 50,
            "Discount": 0.55
        },
        {
            "ProductName": "A001",
            "Explain": "蘋果",
            "CategoryName": "A",
            "UnitPrice": 60,
            "Discount": 0.0
        }
    ]
}
```
- - -

