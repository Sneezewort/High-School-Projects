public class BinarySearchYouTry {
	public static void main (String[]args) {

//You Try Program
		/*int[] arr = new int[20];

		for (int i = 0; i < arr.length; i++) {
			arr[i] = (int)((Math.random()*25)+1);
		}
		for(int i = 1; i < arr.length; i++){
			int j = i;
			while(j > 0 && arr[j] < arr[j-1]){
				int temp = arr[j];
				arr[j] = arr[j-1];
				arr[j-1] = temp;
				j--;
			}

		}
		for(int i = 0; i < arr.length; i++)
			System.out.print(arr[i]+" ");

		int lo = 0;
		int hi = arr.length-1;
		int key = 10;
		boolean yes = false;

		while(lo <= hi){
			int mid = (lo + hi)/2;
			if(arr[mid] == key){
				yes = true;
				break;
			}
			else if(arr[mid] < key){
				lo = mid + 1;
			}
			else if(arr[mid] > key){
				hi = mid - 1;
			}
		}
		System.out.println("\n");

		if(yes == true)
			System.out.println(key + " is in the array.");
		else
			System.out.println(key + " is NOT in the array.");

//Program I
		int[] arr = new int[1000];

		for (int i = 0; i < arr.length; i++) {
			arr[i] = (int)((Math.random()*10000)+1);
		}
		for(int i = 1; i < arr.length; i++){
			int j = i;
			while(j > 0 && arr[j] < arr[j-1]){
				int temp = arr[j];
				arr[j] = arr[j-1];
				arr[j-1] = temp;
				j--;
			}

		}

		int lo = 0;
		int hi = arr.length-1;
		int key = (int)((Math.random()*10000)+1);
		int counter = 0;
		boolean yes = false;

		while(lo <= hi){
			int mid = (lo + hi)/2;
			if(arr[mid] == key){
				yes = true;
				counter++;
				break;
			}
			else if(arr[mid] < key){
				counter++;
				lo = mid + 1;
			}
			else if(arr[mid] > key){
				counter++;
				hi = mid - 1;
			}
		}

		if(yes == true)
			System.out.println(key + " is in the array.  The computer searched " + counter + " times.\n");
		else
			System.out.println(key + " is NOT in the array.  The computer searched " + counter + " times.\n");

//Program II
		int[] arr = new int[1000];

		for (int i = 0; i < arr.length; i++) {
			arr[i] = (int)((Math.random()*10000)+1);
		}
		for(int i = 1; i < arr.length; i++){
			int j = i;
			while(j > 0 && arr[j] < arr[j-1]){
				int temp = arr[j];
				arr[j] = arr[j-1];
				arr[j-1] = temp;
				j--;
			}

		}

		int lo = 0;
		int hi = arr.length-1;
		int key = (int)((Math.random()*10000)+1);
		int rcounter = 0;
		int bcounter = 0;
		boolean yes = false;

		for (int i = 0; i < arr.length; i++) {
			if (arr[i] == key) {
				rcounter++;
				yes = true;
				break;
			}
			else {
				rcounter++;
			}
		}

		while(lo <= hi){
			int mid = (lo + hi)/2;
			if(arr[mid] == key){
				yes = true;
				bcounter++;
				break;
			}
			else if(arr[mid] < key){
				bcounter++;
				lo = mid + 1;
			}
			else if(arr[mid] > key){
				bcounter++;
				hi = mid - 1;
			}
		}

		if(yes == true)
			System.out.println(key + " is in the array.\nThe regular search ran " + rcounter + " times.\nThe binary search ran " + bcounter + " times.\n");
		else
			System.out.println(key + " is NOT in the array.\nThe regular search ran " + rcounter + " times.\nThe binary search ran " + bcounter + " times.\n");*/

//Program III

	}
}