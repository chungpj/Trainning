const posts = [ 
	{id: 1, name: 'First post'},
	{id: 2, name: 'Second post'}
];
getPosts = () => {
	setTimeout(() => {
		let output = '';
		posts.forEach((post, index) => {
			output += `<li>${post.name}</li>`
		});
		document.getElementById("demo").innerHTML = output;
	}, 2000);
}
createPost = (post) => {
	return new Promise((resolve, reject) => {
		setTimeout(() => {
			posts.push(post);
			
			//change err value 
			const err = false;
			if(!err){
				resolve();
			}else {
				reject('Error: createPost failed!');
			}
		}, 5000);
	});
}

//Promise.all
const promise1 = Promise.resolve('Hello World');
const promise2 = 100;
const promise3 = new Promise((resolve, reject) => {
	setTimeout(resolve, 2000, 'Goodbye');
});
const promise4 = fetch('https://jsonplaceholder.typicode.com/users')
						.then(res => {
							if(res.ok){
								return res.json();
							}else{
								document.getElementById("errMessage").innerHTML = 'Error: fetch failed!';
							}
						}).catch((error) => {
						  console.log(error)
						});

Init = () => {
	document.getElementById("title").innerHTML = 'Demo Promise'
	
	createPost({id: 3, name: 'Third post'})
		.then(getPosts)
		.catch(err => document.getElementById("errMessage").innerHTML = err);
		
	Promise.all([promise1, promise2, promise3, promise4])
			.then(values => {
				console.log(values);
				document.getElementById("demo").innerHTML = values;
			});
}

Init();