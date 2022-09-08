function calculate(model, group, width, height) {
	//Gettign values ffrom sizes form for Horizontals and Verticals and Prints the result
	let colorCode = 0;	//default color
	let modelCode = 0; // default model
	let totalPrice = 0;

	// Vertical MODELS ----------------------------
	let verticalModels = ["89 мм", "127 мм", "89 мм Al"];
	// Vertical COLORS
	let verticalColors = [
		["rococo",
			"polly",
			"beata",
			"melisa",
			"moon",
			"vanessa",
			"sandra",
			"jenny",
			"ray",
			"van gogh",
			"silk",
			"pasifico",
			"lima",
			"melisa bo",
			"metalic",
			"lumina",
			"guardian",
			"juno",
			"glitter",
			"tundra",
			"carina bo",
			"porto",
			"juno bo",
			"jacquard natalie",
			"banbury",
			"monterey",
			"cotton flower",
			"green screen eco",
			"oslo",
			"monroe",
			"jacquard cube",
			"hampton",
			"valencia bo"],	//89
		["corra",
			"creppe",
			"jenny",
			"shantung",
			"fiesta",
			"ray",
			"vanesa",
			"itaca",
			"van gogh",
			"aneta",
			"patricia",
			"carina bo",
			"screen",
			"green screen eco"],	//127
		["Бяла(0150)",
			"4459",
			"7113",
			"7010",
			"4451",
			"7418",
			"0150P",
			"1858P",
			"4459P",
			"7113P",
			"7010P",
			"4451P"]	//AL
	];

	let verticalTable = [
		[
			9.90, 10.50, 11.90, 11.90, 12.50, 12.90, 12.90, 12.90, 12.90, 12.90, 14.50, 18.90, 22.90, 24.90, 26.90,
			29.90, 31.90, 32.90, 33.50, 36.90, 38.90, 41.90, 44.50, 46.50, 46.90, 48.50, 49.90, 55.90, 59.50, 59.90,
			64.90, 69.90, 74.90
		], // 89mm
		[12.50, 13.50, 14.50, 14.50, 15.50, 15.90, 16.50, 16.90, 16.90, 17.90, 20.90, 41.50, 49.90, 58.50], //127mm
		[56.90, 61.50, 61.50, 61.50, 61.50, 61.50, 89.37, 91.50, 96.50, 96.50, 96.50, 96.50] //AL
	];

	getModel();
	getColor();
	let error = checkBoundories(modelCode, width, height);
	return printFinalPrice(error);

	function getColor() {
		colorCode = verticalColors[modelCode].indexOf(group);
	}

	function getModel() {
		modelCode = verticalModels.indexOf(model);	//models are the rows in  horizontalTable
	}

	// checkes the width and hitght
	function checkBoundories(model, width, height) {
		let errorMSG = "Зададените размери са извън позволената ширина/височина на продукта";
		let errorMSG_ = "Зададените размери са извън позволената площ на продукта";

		switch (model) {
			case 0:
			case 2:
			case 1:
				if (width < 20 || width > 400 || height < 20 || height > 400) {
					return errorMSG;
				} break;
		}

		if ((width * height) / 10000 > 16) {
			return errorMSG_;
		}

		return undefined;
	}

	function printFinalPrice(error) {

		if (error !== undefined) {
			return error
		}

		let squareMeters;
		let pricePerSquareMeter = 0;
		let discount = 6;	//precent discount

		squareMeters = width * height / 10000;
		if (squareMeters < 0.5) {
			squareMeters = 0.5;
		}

		pricePerSquareMeter = verticalTable[modelCode][colorCode];
		totalPrice = totalPrice + (squareMeters * pricePerSquareMeter);
		totalPrice = totalPrice + (27.9 * width / 100);
		totalPrice -= totalPrice * (discount / 100);

		if (totalPrice == 0) {
			return "Неподдържан цвят за този модел";
		}
		else {
			return totalPrice;
		}
	}
}

export default {
    calculate,
}