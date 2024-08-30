import React from "react";

function renderPostTable() {
  return (
    <div className="table-responsive mt-5">
      <table className="table table-bordered table-dark">
        <thead>
          <tr>
            <th scope="col">PostId (PK)</th>
            <th scope="col">Title</th>
            <th scope="col">Content</th>
            <th scope="col">CRUD Operations</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <th scope="row">1</th>
            <td>Post 1 Title</td>
            <td>Post 1 Content</td>
            <td>
              <button className="btn btn-secondary btn-lg ml-0 mx-3 my-3">Update</button>
              <button className="btn btn-danger btn-lg ">Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

export default function App() {
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <h1>Hello world</h1>
          {renderPostTable()}
        </div>
      </div>
    </div>
  );
}
