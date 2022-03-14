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
			"tundra",
			"porto",
			"albery",
			"carina bo",
			"jacquard natalie",
			"banbury",
			"strata spc",
			"juno bo",
			"monterey",
			"blossom print",
			"green screen eco",
			"oslo",
			"monroe",
			"jacquard cube",
			"hampton",],	//89
		["corra",
			"creppe",
			"jenny",
			"shantung",
			"fiesta",
			"vanesa",
			"ray",
			"aneta",
			"itaca",
			"van gogh",
			"patricia",
			"mountain",
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
		[10.44, 11.16, 12.72, 12.72, 13.08, 13.56, 13.56, 13.80, 13.80, 13.80, 15.00, 21.24, 25.08, 26.28, 29.16, 32.76, 32.76, 36.60, 38.28, 41.88, 43.80, 43.80, 49.08, 49.08, 49.08, 50.28, 50.28, 57.48, 59.40, 61.09, 62.29, 68.29, 71.86],	// 89mm
		[10.44, 11.16, 13.08, 12.49, 13.80, 14.28, 14.28, 16.68, 16.68, 16.68, 20.28, 39.59, 43.80, 50.28, 57.48],	//127mm
		[58, 63, 59, 88, 59, 88, 59, 88, 59, 88, 59, 88, 89, 37, 93, 13, 93, 13, 93, 13, 93, 13, 93, 13]	//AL
	]

	getModel();
	getColor();
	let error = checkBoundories(modelCode, width, height);
	return printFinalPrice(error);


	//////Prints an option TAG whit argument gived
	//////function printElement(array, index) {
	//////	document.write(array[index]);
	//////}

	//////function getVerticalType(model) {

	//////	$('#selectColorvs').find('option').remove();
	//////	var type = model.selectedIndex;
	//////	option = verticalColors[type];
	//////	for (var i = 0; i < option.length; i++) {
	//////		$('#selectColorvs').append("<option value=" + 'option[i]' + ">" + option[i] + "</option>");
	//////	}
	//////}


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
		totalPrice = totalPrice + (25.08 * width / 100);
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