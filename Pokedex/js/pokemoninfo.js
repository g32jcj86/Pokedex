//判斷是否弱點
function weakness(typeA, typeB, num) {
    var x = 1;
    var result = 1;
    var temp = typeA;
    var type = "";
    for (i = 0; i < 2; i++) {
        switch (num) {
            case 0://一般
                if (temp == "岩石" || temp == "鋼")
                    x = 0.5;
                else if (temp == "幽靈")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("一般")}" id="weakA">${"一般"}</div>`;
                break;
            case 1://格鬥
                if (temp == "飛行" || temp == "毒" || temp == "蟲" || temp == "超能力" || temp == "妖精")
                    x = 0.5;
                else if (temp == "幽靈")
                    x = 0;
                else if (temp == "一般" || temp == "岩石" || temp == "鋼" || temp == "冰" || temp == "惡")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("格鬥")}" id="weakA">${"格鬥"}</div>`;
                break;
            case 2://飛行
                if (temp == "岩石" || temp == "鋼" || temp == "電")
                    x = 0.5;
                else if (temp == "格鬥" || temp == "蟲" || temp == "草")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("飛行")}" id="weakA">${"飛行"}</div>`;
                break;
            case 3://毒
                if (temp == "岩石" || temp == "毒" || temp == "地面" || temp == "幽靈")
                    x = 0.5;
                else if (temp == "妖精" || temp == "草")
                    x = 2;
                else if (temp == "鋼")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("毒")}" id="weakA">${"毒"}</div>`;
                break;
            case 4://地面
                if (temp == "蟲" || temp == "草")
                    x = 0.5;
                else if (temp == "毒" || temp == "岩石" || temp == "鋼" || temp == "火" || temp == "電")
                    x = 2;
                else if (temp == "飛行")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("地面")}" id="weakA">${"地面"}</div>`;
                break;
            case 5://岩石
                if (temp == "格鬥" || temp == "地面" || temp == "鋼")
                    x = 0.5;
                else if (temp == "飛行" || temp == "蟲" || temp == "火" || temp == "冰")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("岩石")}" id="weakA">${"岩石"}</div>`;
                break;
            case 6://蟲
                if (temp == "格鬥" || temp == "飛行" || temp == "毒" || temp == "幽靈" || temp == "鋼" || temp == "火" || temp == "妖精")
                    x = 0.5;
                else if (temp == "草" || temp == "超能力" || temp == "惡")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("蟲")}" id="weakA">${"蟲"}</div>`;
                break;
            case 7://幽靈
                if (temp == "惡")
                    x = 0.5;
                else if (temp == "幽靈" || temp == "超能力")
                    x = 2;
                else if (temp == "一般")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("幽靈")}" id="weakA">${"幽靈"}</div>`;
                break;
            case 8://鋼
                if (temp == "鋼" || temp == "火" || temp == "水" || temp == "電")
                    x = 0.5;
                else if (temp == "岩石" || temp == "冰" || temp == "妖精")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("鋼")}" id="weakA">${"鋼"}</div>`;
                break;
            case 9://火
                if (temp == "岩石" || temp == "火" || temp == "水" || temp == "龍")
                    x = 0.5;
                else if (temp == "蟲" || temp == "鋼" || temp == "草" || temp == "冰")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("火")}" id="weakA">${"火"}</div>`;
                break;
            case 10://水
                if (temp == "水" || temp == "草" || temp == "龍")
                    x = 0.5;
                else if (temp == "地面" || temp == "岩石" || temp == "火")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("水")}" id="weakA">${"水"}</div>`;
                break;
            case 11://草
                if (temp == "飛行" || temp == "毒" || temp == "蟲" || temp == "鋼" || temp == "火" || temp == "草" || temp == "龍")
                    x = 0.5;
                else if (temp == "地面" || temp == "岩石" || temp == "水")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("草")}" id="weakA">${"草"}</div>`;
                break;
            case 12://電
                if (temp == "草" || temp == "電" || temp == "龍")
                    x = 0.5;
                else if (temp == "飛行" || temp == "水")
                    x = 2;
                else if (temp == "地面")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("電")}" id="weakA">${"電"}</div>`;
                break;
            case 13://超能力
                if (temp == "鋼" || temp == "超能力")
                    x = 0.5;
                else if (temp == "格鬥" || temp == "毒")
                    x = 2;
                else if (temp == "惡")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("超能力")}" id="weakA">${"超能力"}</div>`;
                break;
            case 14://冰
                if (temp == "鋼" || temp == "火" || temp == "水" || temp == "冰")
                    x = 0.5;
                else if (temp == "飛行" || temp == "地面" || temp == "龍" || temp == "草")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("冰")}" id="weakA">${"冰"}</div>`;
                break;
            case 15://龍
                if (temp == "鋼")
                    x = 0.5;
                else if (temp == "龍")
                    x = 2;
                else if (temp == "妖精")
                    x = 0;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("龍")}" id="weakA">${"龍"}</div>`;
                break;
            case 16://惡
                if (temp == "格鬥" || temp == "惡" || temp == "妖精")
                    x = 0.5;
                else if (temp == "幽靈" || temp == "超能力")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("惡")}" id="weakA">${"惡"}</div>`;
                break;
            case 17://妖精
                if (temp == "毒" || temp == "鋼" || temp == "火")
                    x = 0.5;
                else if (temp == "格鬥" || temp == "龍" || temp == "惡")
                    x = 2;
                result = result * x;
                x = 1;
                temp = typeB;
                type = `<div class="typeOf ${pokemonType("妖精")}" id="weakA">${"妖精"}</div>`;
                break;
        }
    }
    //result大於1則為該寶可夢弱點
    if (result > 1) {
        $(".weakness").append(type);
    }
}

function pokemonType(string) {
    switch (string) {
        case "一般":
            return "bgColorNormal";
            break;
        case "格鬥":
            return "bgColorFight";
            break;
        case "飛行":
            return "bgColorFly";
            break;
        case "毒":
            return "bgColorPoison";
            break;
        case "地面":
            return "bgColorGround";
            break;
        case "岩石":
            return "bgColorStone";
            break;
        case "蟲":
            return "bgColorBug";
            break;
        case "幽靈":
            return "bgColorGhost";
            break;
        case "鋼":
            return "bgColorSteel";
            break;
        case "火":
            return "bgColorFire";
            break;
        case "水":
            return "bgColorWater";
            break;
        case "草":
            return "bgColorGrass";
            break;
        case "電":
            return "bgColorEle";
            break;
        case "超能力":
            return "bgColorSuperPower";
            break;
        case "冰":
            return "bgColorIce";
            break;
        case "龍":
            return "bgColorDargon";
            break;
        case "惡":
            return "bgColorDark";
            break;
        case "妖精":
            return "bgColorFairy";
            break;
    }
}
