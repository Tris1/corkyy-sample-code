import React from "react";
import "./addtodo.scss";
import { TextField, Button } from "@mui/material";
import { IToDo } from "../../types/global.types";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { baseUrl } from "../../constants/url.constant";

const AddTodo: React.FC = () => {
  const [newTodo, setNewTodo] = React.useState<Partial<IToDo>>({
    todoText: "",
  });

  const redirect = useNavigate();

  const changeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setNewTodo({
      ...newTodo,
      [event.target.name]: event.target.value,
    });
  };

  const handleSaveBtnClick = () => {
    if (newTodo.todoText === "") {
      alert("Please enter some text");
      return;
    }

    const data: Partial<IToDo> = {
      todoText: newTodo.todoText,
    };

    axios
      .post(baseUrl, data)
      .then((response) =>
        redirect("/todos", { state: { message: "Todo Saved!" } })
      )
      .catch((error) => alert("Unable to save new Todo. Please try again."));
  };

  const handleBackBtnClick = () => {
    redirect("/todos");
  };

  return (
    <div className="addtodo">
      <h2>Add New Todo</h2>
      <TextField
        autoComplete="off"
        label="What would you like to do?"
        multiline={true}
        rows={5}
        variant="outlined"
        name="todoText"
        sx={{
          width: 250
        }}
        value={newTodo.todoText}
        onChange={changeHandler}
      />
      <div>
        <Button variant="outlined" color="primary" onClick={handleSaveBtnClick}>
          Save
        </Button>
        <Button
          variant="outlined"
          color="secondary"
          onClick={handleBackBtnClick}
        >
          Back
        </Button>
      </div>
    </div>
  );
};

export default AddTodo;
